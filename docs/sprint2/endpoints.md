## YourScope Backend REST API Documentation
This is the documentation for the YourScope API created by Wenduo Sky. Within this document you will find information pertaining to the nature of the API (the structure of the response body, the nature of authentication, etc) as well as documentation on each of the endpoints that are exposed throuhgh this API.

### Response Body

All exposed endpoints within the API will return a consistent object which has the following structure:

```csharp
public class ApiResponse
{
    public int StatusCode;
    public object? Data;
    public IEnumerable<string>? Errors;
    public string? Message;
    public bool? Successful;
    public Exception? Exception;
}
```

### User Accounts

<details>
 <summary><code>GET</code> <code><b>/api/accounts/v1/check-registered/{email}</b></code> <code>(checks for the existence of an email in the database)</code></summary>

##### Parameters

> | Name      |  Type     | Data Type               | Description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | email      |  required path parameter | string   | A path parameter representing the email to be searched for.  |

##### Responses

> | Status Code     | content-type                      | Response                                                            |Description|
> |---------------|-----------------------------------|-----------------------------------------------------------------|-----|
> | `200`         | `application/json;charset=UTF-8`        | `false`                                |Response when email has not been registered yet.|
> | `200`         | `application/json;charset=UTF-8`        | `true`                                |Response when email has already been registered.|
> | `404`         | `application/json;charset=UTF-8`                | `None`                            |If the path parameter is not provided.|
</details>

<details>
 <summary><code>POST</code> <code><b>/api/accounts/v1/student/register</b></code> <code>(Registers a new student given their information)</code></summary>

##### Parameters

> | Name      |  Type     | Data Type               | Description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | email      |  required in request body | string   | The user's email address.  |
> |firstName|required in the request body|string|The user's first name.|
> |middleName|optional in the request body|string|The user's middle name (if any).|
> |lastName|required in the request body|string|The user's last name.|
> |birthday|required in the request body|datetime|A datetime string representing the user's birthdate.|
> |affiliation|required in the request body|string|The user's affiliation (in the case of a student, represents the name of the school the student goes to).|
> |grade|required in the request body|integer between 8 and 13|The student's current grade.|
> |password|required in the request body|string|The user's password.|

##### Sample Request Body

```json
{
  "email": "john.doe@gmail.com",
  "firstName": "John",
  "middleName": "Powell",
  "lastName": "Doe",
  "birthday": "2023-06-28T03:41:44.973Z",
  "affiliation": "Stouffville District Secondary School",
  "grade": 11,
  "password": "bazinga"
}
```

```json
{
  "email": "jane.doe@gmail.com",
  "firstName": "Jane",
  "lastName": "Doe",
  "birthday": "2023-06-28T03:41:44.973Z",
  "affiliation": "Hogwarts School of Witchcraft and Wizardry",
  "grade": 9,
  "password": "AvaDakeDavRa"
}
```

##### Responses

> | Status Code     | content-type                      | Response                                                            |Description|
> |---------------|-----------------------------------|-----------------------------------------------------------------|-----|
> | `200`         | `application/json;charset=UTF-8`        | `true`                                |The registration was successful and encountered no errors.|
> | `400`         | `text/plain;charset=UTF-8`        | `{email} has already been registered!`                                |If the passed in email has already been registered.|
> | `400`         | `application/json;charset=UTF-8`                |             `{"errors": {"$": ["JSON deserialization for type 'yourscope_api.entities.UserRegistrationDto' was missing required properties, including the following: property"]}}`                |If any required parameters are missing.|

##### Sample Response Body
Missing required parameters.
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-f253f8dee6ddc5946118c738276965c6-80c2ce8979e338b1-00",
  "errors": {
    "$": [
      "JSON deserialization for type 'yourscope_api.entities.UserRegistrationDto' was missing required properties, including the following: email"
    ],
    "userInfo": [
      "The userInfo field is required."
    ]
  }
}
```
Registration successful.
```json
true
```
</details>

<details>
 <summary><code>POST</code> <code><b>/api/accounts/v1/login</b></code> <code>(Used to log in an existing user and generate a JWT auth token)</code></summary>

##### Parameters

> | Name      |  Type     | Data Type               | Description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | email      |  required in request body | string   | The user's email address.  |
> |password|required in the request body|string|The user's password.|

##### Sample Request Body

```json
{
  "email": "john.doe@gmail.com",
  "password": "bazinga"
}
```

##### Responses

> | Status Code     | content-type                      | Response                                                            |Description|
> |---------------|-----------------------------------|-----------------------------------------------------------------|-----|
> | `200`         | `text/plain;charset=UTF-8`        | `JWT token`                                |The login was successful and a JWT token is returned which is needed for future authentication.|
> | `401`         | `text/plain;charset=UTF-8`        | `Incorrect email or password.`                                |Either the passed in email or the passed in password was incorrect.|
</details>

<details>
 <summary><code>POST</code> <code><b>/api/accounts/v1/{email}/send-password-reset-email</b></code> <code>(Used to send an email to the user to reset their password)</code></summary>

##### Parameters

> | Name      |  Type     | Data Type               | Description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | email      |  required path parameter | string   | The user's email address.  |

##### Responses

> | Status Code     | content-type                      | Response                                                            |Description|
> |---------------|-----------------------------------|-----------------------------------------------------------------|-----|
> | `200`         | `application/json;charset=UTF-8`        | `true`                                |The email was sent successfully to the user's email address.|
> | `404`         | `text/plain;charset=UTF-8`        | `Email is not registered.`                                |The provided email address is not registered under any account.|
</details>