# Member endpoints

### Create member - [POST]() /member

Adds a new member to the database.

**Body:**

```json
{
    "name": "Hugo Carvalho",
    "email": "hugo.carvalho@mail.com",
    "address": "Av. Gen. Humberto Delgado 584",
    "phoneNumber": "+351939393939"
}
```

**Returns:** If successful, the code 201 and a copy of the created member.

```json
{
    "id": 1,
    "name": "Hugo Carvalho",
    "email": "hugo.carvalho@mail.com",
    "address": "Av. Gen. Humberto Delgado 584",
    "phoneNumber": "+351939393939"
}
```

Otherwise, the code 400 and an error message.

---

### Find all members - [GET]() /member/all?*pageNumber*&*pageSize*

Retrieves a list of the lastest members.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| pageNumber | Number | 1             |
| pageSize   | Number | 20            |

**Returns:** If successful, the code 200, the total number of members and a list of members.

```json
{
    "total": 3,
    "array": [
        {
            "id": 1,
            "name": "Hugo Carvalho",
            "email": "hugo.carvalho@mail.com",
            "address": "Av. Gen. Humberto Delgado 584",
            "phoneNumber": "+351939393939"
        },
        {
            "id": 2,
            "name": "Érica Lopes",
            "email": "erica.lopes@mail.com",
            "address": "Praça de Parada Leitão 65",
            "phoneNumber": "+351919191919"
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Find members - [GET]() /member/search?*pageNumber*&*pageSize*&*id*&*memberName*

Retrieves a list of members matching the specified criteria.

**Parameters:**

| Parameter   | Type   | Default value |
|:------------|:-------|:--------------|
| pageNumber  | Number | 1             |
| pageSize    | Number | 20            |
| id          | Number | 0             |
| memberName  | String | null          |
| email       | String | null          |
| address     | String | null          |
| phoneNumber | String | null          |

**Return:** If successful, the code 200, the total number of members that meet the criteria and a list of members.

```json
{
    "total": 3,
    "array": [
        {
            "id": 1,
            "name": "Hugo Carvalho",
            "email": "hugo.carvalho@mail.com",
            "address": "Av. Gen. Humberto Delgado 584",
            "phoneNumber": "+351939393939"
        },
        {
            "id": 2,
            "name": "Érica Lopes",
            "email": "erica.lopes@mail.com",
            "address": "Praça de Parada Leitão 65",
            "phoneNumber": "+351919191919"
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Find one member - [GET]() /member?id

Retrieves a single member using its ID.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| id         | Number | 0             |

**Returns:** If successful, the code 200 and a single member.

```json
{
    "id": 1,
    "name": "Hugo Carvalho",
    "email": "hugo.carvalho@mail.com",
    "address": "Av. Gen. Humberto Delgado 584",
    "phoneNumber": "+351939393939",
    "borrows": [
        {
            "id": 1,
            "title": "The Lord of the Rings: The Fellowship of the Ring",
            "borrowDate": "2024-07-16",
            "returnDate": "2024-07-17"
        },
        {
            "id": 2,
            "title": "The Lord of the Rings: The Two Towers",
            "borrowDate": "2024-07-17",
            "returnDate": "2024-07-21"
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Update member - [PUT]() /member

Updates an existing member.

**Body:**

```json
{
    "id": 1,
    "name": "Hugo Henrique",
    "email": "hugo.carvalho@mail.com",
    "address": "Av. Gen. Humberto Delgado 584",
    "phoneNumber": "+351939393939"
}
```

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---

### Delete member - [DELETE]() /member?id

Deletes a member from the database.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| id         | Number | 0             |

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---