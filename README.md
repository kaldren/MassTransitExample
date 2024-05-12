# Microservices E-Commerce System

This project demonstrates a basic microservices architecture for an e-commerce application using .NET, MassTransit, and RabbitMQ. It includes several independent services, such as a Product Catalog service, Order service, and Inventory service, each responsible for a distinct aspect of the application.

## Architecture Overview

The system consists of the following components:
- **Blazor.UI**: A Blazor-based frontend that provides interactive user interfaces for product browsing and order placement.
- **Product Catalog Microservice**: Manages product information and serves it to the frontend.
- **Order Microservice**: Processes orders posted from the frontend and publishes order events to RabbitMQ.
- **Inventory Microservice**: Subscribes to order events, checks inventory availability, and publishes inventory status back to the order service.

Each service communicates through messages facilitated by RabbitMQ, ensuring loose coupling and high scalability.

## Getting Started

### Prerequisites
- .NET 6.0 or later
- RabbitMQ server (can be run as a Docker container)

### Setting Up the Environment
0. Setup RabbitMQ (Google how to do it for your environment)
1. Clone the repository:
   ```bash
   git clone https://github.com/kaldren/MassTransitExample.git
2. Navigate to the project directory:
   ```bash
   cd MassTransitExample
3. Run each service
   ```bash
   dotnet run --project .src/Blazor.UI
   dotnet run --project .src/Inventory.API
   dotnet run --project .src/Order.API
   dotnet run --project .src/ProductCatalog.API
