# Author endpoints

### Create author - [POST]() /author

Adds a new author to the database.

**Body:**

```json
{
    "name": "J.R.R. Tolkien",
    "imageUrl": "https://image.jpg"
}
```

**Returns:** If successful, the code 201 and a copy of the created author.

```json
{
    "id": 1,
    "name": "J.R.R. Tolkien",
    "imageUrl": "https://image.jpg"
}
```

Otherwise, the code 400 and an error message.

---

### Find all authors - [GET]() /author?*pageNumber*&*pageSize*

Retrieves a list of the lastest authors.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| pageNumber | Number | 1             |
| pageSize   | Number | 16            |

**Returns:** If successful, the code 200, the total number of authors and a list of authors.

```json
{
    "total": 3,
    "array": [
        {
            "id": 1,
            "name": "J.R.R. Tolkien",
            "imageUrl": "https://image.jpg"
        },
        {
            "id": 2,
            "name": "J.K. Rowling",
            "imageUrl": "https://image.jpg"
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Find authors - [GET]() /author/search?*pageNumber*&*pageSize*&*id*&*name*

Retrieves a list of authors matching the specified criteria.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| pageNumber | Number | 1             |
| pageSize   | Number | 16            |
| id         | Number | 0             |
| name       | String | null          |

**Return:** If successful, the code 200, the total number of authors that meet the criteria and a list of authors.

```json
{
    "total": 3,
    "array": [
        {
            "id": 1,
            "name": "J.R.R. Tolkien",
            "imageUrl": "https://image.jpg"
        },
        {
            "id": 2,
            "name": "J.K. Rowling",
            "imageUrl": "https://image.jpg"
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Find one author - [GET]() /author/*id*

Retrieves a single author using its ID.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| id         | Number | 0             |

**Returns:** If successful, the code 200 and a single author.

```json
{
    "id": 1,
    "name": "J.R.R. Tolkien",
    "imageUrl": "https://image.jpg",
    "books": [
        {
            "id": 1,
            "title": "The Lord of the Rings: The Fellowship of the Ring",
            "imageUrl": "https://image.jpg"
        },
        {
            "id": 2,
            "title": "The Lord of the Rings: The Two Towers",
            "imageUrl": "https://image.jpg"
        },
        ...
    ]
}
```

Otherwise, the code 404 and an error message.

---

### Update author - [PUT]() /author

Updates an existing author. The Id specified in the body is used to find the original entity.

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

### Delete author - [DELETE]() /author/*id*

Deletes a author from the database.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| id         | Number | 0             |

**Returns:** If successful, the code 200. Otherwise, the code 404 and an error message.

---