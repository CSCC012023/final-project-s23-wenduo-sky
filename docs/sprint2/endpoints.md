## YourScope Backend REST API Documentation
This is the documentation for the YourScope API created by Wenduo Sky. Within this document, you will find information pertaining to the nature of the API (the structure of the response body, the nature of authentication, etc) as well as documentation on each of the endpoints that are exposed through this API.

### Response Body

All exposed endpoints within the API will return a consistent object which has the following structure:

```csharp
class ApiResponse
{
    int StatusCode;
    object? Data;
    IEnumerable<string>? Errors;
    string? Message;
    bool? Successful;
    Exception? Exception;
}
```

In the response body, the above class will be serialized into a JSON format where each field will be camelCased; thus, responses will have the following structure:

```json
{
  "statusCode": 200,
  "data": /* The state of the resource */,
  "errors": /* An array of error messages */,
  "message": "Some message",
  "successful": /* A boolean */,
  "exception": /* An exception object */
}
```

Here are what each of the above fields represents, and how each endpoint will use them:

- `statusCode`: This represents the HTTP response status code indicating information about the completion or lack thereof of the request.
- `data`: This represents the state of the resource _after_ the requested operation has been applied to the resource. With respect to `GET` endpoints, this would represent the state of the resource that you are trying to access. This value will be `null` if there was any sort of problem during the request (404, 401, 500, etc). This will most likely be the field containing the bulk of the information you want to access.
- `errors`: This is a list of error messages that may help to diagnose the root cause of failures within the API.
- `message`: This is a string that may contain a meaningful message in order to indicate the status of the response in human-readable language.
- `successful`: This is a boolean representing the 'success' of a request; the definition of 'success' may differ from endpoint to endpoint. For example, the registration endpoint will return `true` for this field if registration is successful and `false` otherwise.
- `exception`: This is a JSON serialized object representing the exception that caused an error within the application, if any.

### Authentication

The YourScope API makes use of a JWT in order to perform authentication on certain endpoints. If an endpoint requires authentication, it will be mentioned in its respective entry in the list of endpoints below.

If an endpoint requires authentication, you must pass in a valid JWT in the `Authorization` header when making a request to the API. This header must be formatted as follows (must include `Bearer` as a prefix):

```http
Authorization: Bearer <token>
```

In order to obtain a JWT, you must first register and log in to an account using the respective endpoints. The log-in endpoint will then respond with a JWT that the client may then place in the header of subsequent requests to other endpoints requiring authentication.

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
> | `400`         | `text/plain;charset=UTF-8`        | `{email} has already been registered!`                                |If the passed-in email has already been registered.|
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
> | `401`         | `text/plain;charset=UTF-8`        | `Incorrect email or password.`                                |Either the passed-in email or the passed-in password was incorrect.|
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
