# VehicleAdverts

This project contains two microservices, AdvertsService to list and filter vehicle ads and AdvertsVisitService to log users who query ad details.

## Installation

Follow the steps below to run the project on your local machine.

1. **Cloning the Repository:**

   ```bash
   git clone https://github.com/ozturklut/VehicleAdverts.git

2. **Start the Application Using Docker-compose:**
    docker-compose up -d
   
This will start all microservices and manage dependencies.

# Microservices

**AdvertsService**
This microservice manages operations related to vehicle advertisements.

Technologies: .Net 7, MSSQL , RabbitMQ

URL: http://localhost:5165

API Documentation: Swagger

AdvertsService lists and filters advertisements.

**AdvertsVisitService**
This microservice manages operations related to advertisement visits.

Technologies: .Net 7, MSSQL , RabbitMQ

URL: http://localhost:5244

API Documentation: Swagger

AdvertsVisitService logs users querying advertisement details.

API Usage
For detailed API usage and examples, refer to the respective Swagger documents.
