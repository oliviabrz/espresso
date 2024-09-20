## JournalEntry Table CRUD Operations
### Create
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: POST: /journalentry <br> {espressoBeanId: 0, <br> grinderId: 0, <br> grindSetting: 0, <br> beanWeightInGrams: 0, <br> preExtractionTimeInSeconds: 0, <br> extractionTimeInSeconds: 0, <br> espressoWeightInGrams: 0, <br> bitternessRank: 0, <br> acidityRank: 0, <br> sourRank: 0, <br> cremaRank: 0, <br> satisfactionRank: 0, <br> comments: " ", <br> dateCreate: mm-dd-yyyy,<br> dateUpdate: mm-dd-yyyy}
        api->>+db: insert into table JournalEntry
        db-->>-api: return journalEntry Id
    api-->>-user: return http status code and journalEntry Id
```
### Read
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: GET: /journalentry/{id}
        api->>+db: select from table JournalEntry where id = id
        db-->>-api: return journal entry record
    api-->>-user: return http status code and journal entry record
```
### Update
```mermaid
sequenceDiagram
autonumber

    actor user
    participant api as EspressoApiService
    participant db as EspressoDatabase
    
    user->>+api: PUT: /journalentry/{id} {espressoBeanId: 0, <br> grinderId: 0, <br> grindSetting: 0, <br> beanWeightInGrams: 0, <br> preExtractionTimeInSeconds: 0, <br> extractionTimeInSeconds: 0, <br> espressoWeightInGrams: 0, <br> bitternessRank: 0, <br> acidityRank: 0, <br> sourRank: 0, <br> cremaRank: 0, <br> satisfactionRank: 0, <br> comments: " ", <br> dateCreate: mm-dd-yyyy,<br> dateUpdate: mm-dd-yyyy}
        api->>+db: update table Journal Entry where id = id
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
    
    user->>+api: DELETE: /journalentry/{id}
        api->>+db: delete table JournalEntry where id = id
        db-->>-api: return
    api-->>-user: return http status code
```