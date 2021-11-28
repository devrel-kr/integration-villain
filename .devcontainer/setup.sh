## Update and install some things we should probably have
# apt-get update && export DEBIAN_FRONTEND=noninteractive
# apt-get install -y --no-install-recommends \
#   curl \
#   git \
#   gnupg2 \
#   jq \
#   sudo \
#   zsh

## Instsall nvm
# curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.0/install.sh | bash

## Install .NET 6
# wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
# sudo dpkg -i packages-microsoft-prod.deb
# rm packages-microsoft-prod.deb

# sudo apt-get update; \
#   sudo apt-get install -y apt-transport-https && \
#   sudo apt-get update && \
#   sudo apt-get install -y dotnet-sdk-6.0

## Update to the latest PowerShell
# curl -sSL https://raw.githubusercontent.com/PowerShell/PowerShell/master/tools/install-powershell.sh | bash

## Install Azure Functions Core Tools v4
# curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
# sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
# sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-$(lsb_release -cs)-prod $(lsb_release -cs) main" > /etc/apt/sources.list.d/dotnetdev.list'
# sudo apt-get update
# sudo apt-get install -y azure-functions-core-tools-4

## Enable local HTTPS for .NET
# dotnet dev-certs https --trust
