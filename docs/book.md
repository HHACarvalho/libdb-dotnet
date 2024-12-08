# Book endpoints

### Create book - [POST]() /book

Creates a new book.

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

### Find all books - [GET]() /book?_pageNumber_&_pageSize_

Retrieves a list of the latest books.

**Parameters:**

| Parameter  | Type   | Default value |
| :--------- | :----- | :------------ |
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

### Find books - [GET]() /book/search?_pageNumber_&_pageSize_&_id_&_title_&_year_&_genre_&_authorName_

Retrieves a list of books matching the specified criteria.

**Parameters:**

| Parameter  | Type   | Default value |
| :--------- | :----- | :------------ |
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

### Find one book - [GET]() /book/_id_

Retrieves a single book using its ID.

**Parameters:**

| Parameter | Type   | Default value |
| :-------- | :----- | :------------ |
| id        | Number | 0             |

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

Updates an existing book.

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

### Delete book - [DELETE]() /book/_id_

Deletes an existing book.

**Parameters:**

| Parameter | Type   | Default value |
| :-------- | :----- | :------------ |
| id        | Number | 0             |

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---
