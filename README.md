# EventSourcing-PoC
This is the PoC of an Event Sourced application with Cosmos as EventStore and ReadModel db.

## Project Structure
- WebAPI, The api that the website or apps could connect to. It stores commands onto Azure Service Bus and retreives ReadModels from the ReadModel Database. Its secrets are stored in Azure Key Vault. Product images are uploaded to a Blob Container. 
- EventStorePropagator, The Azure Function that triggers when an command is added to the Bus. Loads the aggregate from the EventStore and applies the new command. Secrets are stored as Environment Variables.
- ReadModels, The Azure Function that triggers when an item is added to the Event Store. Contains the projections that handle the events. In this case they all create readmodels in CosmosDb, but that's only becuase the Free account tier on Azure doesnt support Elastic Search. Secrets are stored as Environment Variables. It could easily be expanded to allow for different implementations of read models!

## Database design
[Database Design](https://user-images.githubusercontent.com/35657766/200019504-8020630f-6976-4e21-85c0-269ab6f01174.png)
