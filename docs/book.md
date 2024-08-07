# Book endpoints

### Create book - [POST]() /book

Adds a new book to the database.

**Body:**

```json
{
    "title": "The Lord of the Rings: The Fellowship of the Ring",
    "year": 1954,
    "genre": "Fantasy",
    "imageUrl": "https://image.jpg",
    "authorId": "1"
}
```

**Returns:** If successful, the code 201 and a copy of the created book.

```json
{
    "id": 1,
    "title": "The Lord of the Rings: The Fellowship of the Ring",
    "year": 1954,
    "genre": "Fantasy",
    "imageUrl": "https://image.jpg",
    "author": "J.R.R. Tolkien"
}
```

Otherwise, the code 400 and an error message.

---

### Find all books - [GET]() /book?*pageNumber*&*pageSize*

Retrieves a list of the lastest books.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| pageNumber | Number | 1             |
| pageSize   | Number | 16            |

**Returns:** If successful, the code 200, the total number of books and a list of books.

```json
{
    "total": 36,
    "array": [
        {
            "id": 1,
            "title": "The Lord of the Rings: The Fellowship of the Ring",
            "imageUrl": "https://image.jpg",
            "author": {
                "id": 1,
                "name": "J.R.R. Tolkien"
            }
        },
        {
            "id": 2,
            "title": "The Lord of the Rings: The Return of the King",
            "imageUrl": "https://image.jpg",
            "author": {
                "id": 1,
                "name": "J.R.R. Tolkien"
            }
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Find books - [GET]() /book/search?*pageNumber*&*pageSize*&*id*&*title*&*year*&*genre*&*authorName*

Retrieves a list of books matching the specified criteria.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| pageNumber | Number | 1             |
| pageSize   | Number | 16            |
| id         | Number | 0             |
| title      | String | null          |
| year       | Number | 0             |
| genre      | Number | null          |
| authorName | Number | null          |

**Return:** If successful, the code 200, the total number of books that meet the criteria and a list of books.

```json
{
    "total": 36,
    "array": [
        {
            "id": 1,
            "title": "The Lord of the Rings: The Fellowship of the Ring",
            "imageUrl": "https://image.jpg",
            "author": {
                "id": 1,
                "name": "J.R.R. Tolkien"
            }
        },
        {
            "id": 2,
            "title": "The Lord of the Rings: The Two Towers",
            "imageUrl": "https://image.jpg",
            "author": {
                "id": 1,
                "name": "J.R.R. Tolkien"
            }
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Find one book - [GET]() /book/*id*

Retrieves a single book using its ID.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| id         | Number | 0             |

**Returns:** If successful, the code 200 and a single book.

```json
{
    "id": 1,
    "title": "The Lord of the Rings: The Fellowship of the Ring",
    "year": 1954,
    "genre": "Fantasy",
    "imageUrl": "https://m.media-amazon.com/images/I/71Ep7UNeTtL._SY466_.jpg",
    "author": {
        "id": 1,
        "name": "J.R.R. Tolkien"
    },
    "bookEntries": [
        {
            "id": 1,
            "isbn": "9780008376123"
        },
        {
            "id": 2,
            "isbn": "9780547928210"
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Update book - [PUT]() /book

Updates an existing book. The Id specified in the body is used to find the original entity.

**Body:**

```json
{
    "id": 1,
    "name": "J.R.R. Tolkien",
    "imageUrl": "https://image.jpg"
}
```

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---

### Delete book - [DELETE]() /book/*id*

Deletes a book from the database.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| id         | Number | 0             |

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---