# CloudAIScanner

## Services
### Web Application (SvelteKit)
The main web applocation where the user can interact with the extracted data.
### AI Extraction Service (ASP.NET)
The service responsible for extracting data from the AI providers.
### AI Register Service
The service responsible for storing and retrieving the data from and to the MySQl Database.
### MySql Database
This database is used to store the data of the retrieved AI systems
### MongoDB Database
This database is used to store user data.

## Run
### Prerequisites
- [Git](https://www.git-scm.com/)
- [Docker](https://www.docker.com/products/docker-desktop/)

### Run application
Clone the repository:
```console
git clone https://github.com/DAQEM/CloudAIScanner.git
```
Go to the project directory:
```console
cd CloudAIScanner
```
Edit the .env file located in:
```
CloudAIScanner/Services/WebApp/.env
```
Start the Docker containers:
```console
docker-compose up -d --build
```
Access the web application via:
```
http://localhost:5050/
```
You can now login via the Google account with the email address in the .env file. 
