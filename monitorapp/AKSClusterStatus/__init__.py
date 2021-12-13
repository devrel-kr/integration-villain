import logging
import os

import azure.functions as func

import json
import requests

# access sensitive AKS token value from Azure Key Vault
aks_token = os.getenv('AKSTokenFromKeyVault')
api_url = os.getenv('AKSAPIURL')

def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    name = req.params.get('name')
    if not name:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            name = req_body.get('name')

    if name:
        #return func.HttpResponse(f"Hello, {name}. This HTTP triggered function executed successfully.")

        hed = {'Authorization': 'Bearer ' + aks_token}
        api_url_request = api_url + '/api/v1/namespaces/' + name + '/services/'
        api_url_response = requests.get(api_url_request, headers=hed, verify=False)  

        logging.info('Getting AKS cluster status through services API')

        if api_url_response.status_code == 200:
            return func.HttpResponse(
                json.dumps({
                    'powerState': 'Running'
                }),
                status_code=200
            )
        else:
            return func.HttpResponse(
                json.dumps({
                    'powerState': 'Stopped'
                }),
                status_code=200
            )

    else:
        return func.HttpResponse(
            json.dumps({
                'powerState': 'Stopped'
            }),
            status_code=200
        )
