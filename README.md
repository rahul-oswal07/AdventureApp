# Adventure-Api

## Prerequisite for running dotnet core web api

Download the .Net 6.0 SDK or Runtime from https://dotnet.microsoft.com/download

## Running the api project locally

Open cmd and navigate to ..\adventure-api\adventure.Web and then type 'dotnet run' and press enter,the application will be hosted to localhost
Note: Before running  setup the connection string to connect from database correctly in appSetting.json file


## Prerequisite for running the api project on docker locally

1. Docker setup, if not present then install from here https://docs.docker.com/desktop/windows/install/?msclkid=86114356d0de11ecb673bf157f3ef9a9

## Running the api project on docker locally

Open cmd and navigate to ..\adventure-api (root folder) and run docker-compose up --build and the application should be hosted in http://localhost:8090/swagger/index.html
