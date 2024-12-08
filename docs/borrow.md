# Borrow endpoints

### Create borrow - [POST]() /borrow

Creates a new borrow.

**Body:**

```json
{
	"bookId": "1",
	"memberId": "1",
	"borrowDate": "16-07-2024",
	"dueDate": "06-08-2024"
}
```

**Returns:** If successful, the code 201 and a copy of the created borrow.

```json
{
	"id": 1,
	"bookTitle": "The Lord of the Rings: The Fellowship of the Ring",
	"memberName": "Hugo Carvalho",
	"borrowDate": "16-07-2024",
	"dueDate": "06-08-2024",
	"returnDate": "17-07-2024",
	"fine": 0
}
```

Otherwise, the code 400 and an error message.

---

### Find all borrows - [GET]() /borrow?_pageNumber_&_pageSize_

Retrieves a list of the latest borrows.

**Parameters:**

| Parameter  | Type   | Default value |
| :--------- | :----- | :------------ |
| pageNumber | Number | 1             |
| pageSize   | Number | 16            |

**Returns:** If successful, the code 200, the total number of borrows and a list of borrows.

```json
{
    "total": 8,
    "array": [
        {
            "id": 1,
            "bookTitle": "The Lord of the Rings: The Fellowship of the Ring",
            "memberName": "Hugo Carvalho",
            "borrowDate": "16-07-2024",
            "dueDate": "06-08-2024",
            "returnDate": "17-07-2024",
            "fine": 0
        },
        {
            "id": 2,
            "bookTitle": "The Lord of the Rings: The Two Towers",
            "memberName": "Hugo Carvalho",
            "borrowDate": "17-07-2024",
            "dueDate": "07-08-2024",
            "returnDate": "21-07-2024",
            "fine": 0
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Find one borrow - [GET]() /borrow/_id_

Retrieves a single borrow using its ID.

**Parameters:**

| Parameter | Type   | Default value |
| :-------- | :----- | :------------ |
| id        | Number | 0             |

**Returns:** If successful, the code 200 and a single borrow.

```json
{
	"id": 1,
	"bookTitle": "The Lord of the Rings: The Fellowship of the Ring",
	"memberName": "Hugo Carvalho",
	"borrowDate": "16-07-2024",
	"dueDate": "06-08-2024",
	"returnDate": "17-07-2024",
	"fine": 0
}
```

Otherwise, the code 404 and an error message.

---

### Update borrow - [PUT]() /borrow

Updates an existing borrow.

**Body:**

```json
{
	"id": 1,
	"returnDate": "17-07-2024"
}
```

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---

### Delete borrow - [DELETE]() /borrow/_id_

Deletes an existing borrow.

**Parameters:**

| Parameter | Type   | Default value |
| :-------- | :----- | :------------ |
| id        | Number | 0             |

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---
