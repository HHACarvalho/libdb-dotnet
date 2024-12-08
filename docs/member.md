# Member endpoints

### Create member - [POST]() /member

Creates a new member.

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

### Find all members - [GET]() /member?_pageNumber_&_pageSize_

Retrieves a list of the latest members.

**Parameters:**

| Parameter  | Type   | Default value |
| :--------- | :----- | :------------ |
| pageNumber | Number | 1             |
| pageSize   | Number | 16            |

**Returns:** If successful, the code 200, the total number of members and a list of members.

```json
{
    "total": 5,
    "array": [
        {
            "id": 2,
            "name": "Afonso Esteves",
            "email": "afonso.esteves@mail.com",
            "address": "R. Dr. António Bernardino de Almeida 856",
            "phoneNumber": "+351969696969"
        },
        {
            "id": 3,
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

### Find members - [GET]() /member/search?_pageNumber_&_pageSize_&_id_&_name_&_email_&_address_&_phoneNumber_

Retrieves a list of members matching the specified criteria.

**Parameters:**

| Parameter   | Type   | Default value |
| :---------- | :----- | :------------ |
| pageNumber  | Number | 1             |
| pageSize    | Number | 16            |
| id          | Number | 0             |
| name        | String | null          |
| email       | String | null          |
| address     | String | null          |
| phoneNumber | String | null          |

**Return:** If successful, the code 200, the total number of members that meet the criteria and a list of members.

```json
{
    "total": 5,
    "array": [
        {
            "id": 2,
            "name": "Afonso Esteves",
            "email": "afonso.esteves@mail.com",
            "address": "R. Dr. António Bernardino de Almeida 856",
            "phoneNumber": "+351969696969"
        },
        {
            "id": 3,
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

### Find one member - [GET]() /member/_id_

Retrieves a single member.

**Parameters:**

| Parameter | Type   | Default value |
| :-------- | :----- | :------------ |
| id        | Number | 0             |

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
            "bookTitle": "The Lord of the Rings: The Fellowship of the Ring",
            "borrowDate": "16-07-2024",
            "dueDate": "06-08-2024",
            "returnDate": "17-07-2024",
            "fine": 0.00
        },
        {
            "id": 2,
            "bookTitle": "The Lord of the Rings: The Two Towers",
            "borrowDate": "17-07-2024",
            "dueDate": "07-08-2024",
            "returnDate": "21-07-2024",
            "fine": 0.00
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
	"name": "Hugo Carvalho",
	"email": "hugo.carvalho@mail.com",
	"address": "Av. Gen. Humberto Delgado 584",
	"phoneNumber": "+351939393939"
}
```

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---

### Delete member - [DELETE]() /member/_id_

Deletes an existing member.

**Parameters:**

| Parameter | Type   | Default value |
| :-------- | :----- | :------------ |
| id        | Number | 0             |

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---
