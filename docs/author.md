# Author

### Create author - POST /author

Adds a new author to the database.

**Body:**

```json
{
    "name": "J.R.R. Tolkien",
    "imageUrl": "https://images.gr-assets.com/photos/1307887634p8/282972.jpg"
}
```

**Returns:** If successful, the code 201 and a copy of the created author. Otherwise, the code 400 and an error message.

---

### Find all authors - GET /author/all?*pageNumber*&*pageSize*

Retrieves a list of the lastest authors.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| pageNumber | Number | 1             |
| pageSize   | Number | 20            |

**Returns:** If successful, the code 200 and a list of authors. Otherwise, the code 404 and an error message.

---

### Find authors - GET /author/search?*pageNumber*&*pageSize*&*id*&*authorName*

Retrieves a list of authors matching the specified criteria.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| pageNumber | Number | 1             |
| pageSize   | Number | 20            |
| id         | Number | 0             |
| authorName | String | null          |

**Return:** If successful, the code 200 and a list of authors. Otherwise, the code 404 and an error message.

---

### Find one author - GET /author?id

Retrieves a single author by its ID.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| id         | Number | 0             |

**Returns:** If successful, the code 200 and a single author. Otherwise, the code 404 and an error message.

---

### Update author -  PUT /author

Updates an existing author.

**Body:**

```json
{
    "id": 1,
    "name": "J.R.R. Tolkien",
    "imageUrl": "https://images.gr-assets.com/photos/1307887634p8/282972.jpg"
}
```

**Returns:** If successful, the code 200 and a copy of the updated author. Otherwise, the code 404 and an error message.

---

### Delete author - DELETE /author?id

Deletes a author from the database.

**Parameters:**

| Parameter  | Type   | Default value |
|:-----------|:-------|:--------------|
| id         | Number | 0             |

**Returns:** If successful, the code 200 and a copy of the deleted author. Otherwise, the code 404 and an error message.

---