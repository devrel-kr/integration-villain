## Install apt packages
sudo apt-get update && \
sudo apt-get install -y dos2unix

## Configure git
git config --global pull.rebase false
git config --global core.autocrlf false

## Install node.js 16 LTS
sudo rm ~/.npmrc
source ~/.nvm/nvm.sh
nvm install --lts Gallium

## Install .NET
sudo wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo rm packages-microsoft-prod.deb

sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-2.1 dotnet-sdk-3.1 dotnet-sdk-5.0 dotnet-sdk-6.0

## Install Azure Functions Core Tools v4
# sudo curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
# sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
# sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-$(lsb_release -cs)-prod $(lsb_release -cs) main" > /etc/apt/sources.list.d/dotnetdev.list'

sudo apt-get update && \
sudo apt-get install -y azure-functions-core-tools-4

## Enable local HTTPS for .NET
dotnet dev-certs https --trust
