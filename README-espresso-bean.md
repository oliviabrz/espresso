## EspressoBean Table CRUD Operations
### Create
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: POST: /espressobean <br> {name: " ", <br> roastDate: mm-dd-yyyy, <br> purchasedDate: mm-dd-yyyy, <br> purchasedFrom: " ", <br> roastType: " "}
        api->>+db: insert into table EspressoBean
        db-->>-api: return espressoBean Id
    api-->>-user: return http status code and espressoBean Id
```
### Read
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: GET: /espressobean/{id}
        api->>+db: select from table EspressoBean where id = id
        db-->>-api: return espresso bean record
    api-->>-user: return http status code and espresso bean record
```
### Update
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: PUT: /espressobean/{id} <br> {name: " ", <br> roastDate: mm-dd-yyyy, <br> purchasedDate: mm-dd-yyyy, <br> purchasedFrom: " ", <br> roastType: " "}
        api->>+db: update table EspressoBean where id = id
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
    
    user->>+api: DELETE: /espressobean/{id}
        api->>+db: delete table Grinder where id = id
        db-->>-api: return
    api-->>-user: return http status code
```