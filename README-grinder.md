## Grinder Table CRUD Operations
### Create
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: POST: /grinder {brandName: " ", model: " "}
        api->>+db: insert into table Grinder
        db-->>-api: return Grinder Id
    api-->>-user: return http status code and Grinder Id
```
### Read
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: GET: /grinder/{id}
        api->>+db: select from table Grinder where id = id
        db-->>-api: return grinder record
    api-->>-user: return http status code and grinder record
```
### Update
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: PUT: /grinder/{id} {brandName: " "}
        api->>+db: update table Grinder where id = id
        db-->>-api: return
    api-->>-user: return http status code
```
### Delete
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: DELETE: /grinder/{id}
        api->>+db: delete table Grinder where id = id
        db-->>-api: return
    api-->>-user: return http status code
```