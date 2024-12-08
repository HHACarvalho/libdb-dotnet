# Book Entry endpoints

### Create book entry - [POST]() /bookEntry

Creates a new book entry.

**Body:**

```json
{
	"isbn": "9780008376123",
	"bookId": "1"
}
```

**Returns:** If successful, the code 201 and a copy of the created book entry.

```json
{
	"id": 1,
	"isbn": "9780008376123"
}
```

Otherwise, the code 400 and an error message.

---

### Find all book entries - [GET]() /bookEntry?_pageNumber_&_pageSize_

Retrieves a list of the latest book entries.

**Parameters:**

| Parameter  | Type   | Default value |
| :--------- | :----- | :------------ |
| pageNumber | Number | 1             |
| pageSize   | Number | 16            |

**Returns:** If successful, the code 200, the total number of book entries and a list of books entries.

```json
{
    "total": 3,
    "array": [
        {
            "id": 1,
            "isbn": "9780008376123"
        },
        {
            "id": 2,
            "isbn": "9780008376123"
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Find one book entry - [GET]() /bookEntry/_id_

Retrieves a single book entry.

**Parameters:**

| Parameter | Type   | Default value |
| :-------- | :----- | :------------ |
| id        | Number | 0             |

**Returns:** If successful, the code 200 and a single book entry.

```json
{
	"id": 1,
	"isbn": "9780008376123"
}
```

Otherwise, the code 404 and an error message.

---

### Update book entry - [PUT]() /bookEntry

Updates an existing book entry.

**Body:**

```json
{
	"id": 1,
	"isbn": "9780008376123"
}
```

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---

### Delete book entry - [DELETE]() /bookEntry/_id_

Deletes an existing book entry.

**Parameters:**

| Parameter | Type   | Default value |
| :-------- | :----- | :------------ |
| id        | Number | 0             |

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---
