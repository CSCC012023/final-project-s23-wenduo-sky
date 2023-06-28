## YourScope Backend REST API Documentation

#### User Accounts

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
