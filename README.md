### Book WebAPI 
This project has been developed with [Clean Architecture](https://github.com/iammukeshm/CleanArchitecture.WebApi "CleanArchitecture").
![](https://github.com/saj86/SampleWebApi/blob/main/Image/Architecture.png?raw=true)
<br/>
Clean architecture is a software design philosophy that separates the elements of a design into ring levels. An important goal of clean architecture is to provide developers with a way to organize code in such a way that it encapsulates the business logic but keeps it separate from the delivery mechanism. <br/>

The main rule of clean architecture is that code dependencies can only move from the outer levels inward. Code on the inner layers can have no knowledge of functions on the outer layers. The variables, functions and classes (any entities) that exist in the outer layers can not be mentioned in the more inward levels. It is recommended that data formats also stay separate between levels.
<br/>
Clean architecture was created by Robert C. Martin and promoted on his blog, Uncle Bob. Like other software design philosophies, clean architecture attempts to provide a cost-effective methodology that makes it easier to develop quality code that will perform better, is easier to change and has fewer dependencies.
<br/>
Visually, the levels of clean architecture are organized into an unspecified number of rings. The outer levels of the rings are lower level mechanisms and the inner, higher levels contain policies and Entities.




**Domain**<br/>
All the Entities and the most common models are available here. Note that this Layer will NEVER depend on anything else.<br/>
![Domain](https://github.com/saj86/SampleWebApi/blob/main/Image/Domain.png?raw=true)

**Application**<br/>
Interfaces, CQRS Features, Exceptions, Behaviors are available here.<br/>
![Application](https://github.com/saj86/SampleWebApi/blob/main/Image/Application.png?raw=true)
<br/>
**Bussiness Service**<br/>
The business logic of the project is implemented here and shared between all Presentation layers. <br/>
![Bussiness Service](https://github.com/saj86/SampleWebApi/blob/main/Image/BussinessService.png?raw=true)<br/>

**Infrastructure.Persistence**<br/>
An Application Specific Database will be maintained. This is to ensure that there is no relation between the DBContext classes of Application.<br/>
![Persistence](https://github.com/saj86/SampleWebApi/blob/main/Image/Persistence.png?raw=true)
<br/>
**WebApi**<br/>
This is also known as the Presentation Layer, where you would put in the project that the user can interact with. In our case it is the WebAPI Project.<br/>
![WebApi](https://github.com/saj86/SampleWebApi/blob/main/Image/WebApi.png?raw=true)

# Book Web Api
I wrote a Web API in which we can observe the list of all books.<br>

Moreover, we can insert, update, remove and view all books<br>

###HTTP Result Status
                    
Status  | Description
------------- | -------------
OK(200)  | Response was accepted
BadRequest(400)|Response was rejected
NotFound(404)  | Response was rejected
------------

<strong> <span style="color:#0cbb52;">GET</span>&nbsp; ListBook</strong> <br/>
 `https://url/api/v1/Book `<br/>
##### Get list of books

By using this method, we can see all of the books in the list, and we can find the specific book.

The input parameters include as follows:

- Title
- Author
- Description
<br/>
If the input parameters have values, the assigned response/output will be showed. Otherwise, the whole list of the books will be demonstrated.<br/>
###### Body (Json)
```json
{
  "title": null,
  "description": null,
  "author": null
}
```
###### Sample Result

```json
[
 {
     "id": "441a4389-59af-4a2b-afdb-4e5769490848",
      "title": "Clean Architecture: A Craftsman's Guide to Software Structure and Design",
      "description": "As with his other books, Martin's Clean Architectur.....",
  "author": "Robert C. Martin ",
  "coverImage": "",
  "price": 46.99
},...
]
```
<br/>
<strong> <span style="color:#ffb400;">POST</span>&nbsp;  New Book</strong> <br/>

` https://url/api/v1/Book/Insert`
<br/>

The new book will be registered by this method

###### Body (Json)
```json
{
  "title": "Clean Architecture: A Craftsman's Guide to Software Structure and Design",
  "description": "As with his other books, Martin's Clean Architecture ....",
  "author": "Robert C. Martin ",
  "coverImage": null,
  "price": 46.99
}
```
###### Sample Result
```json
{
 "id": "81716ff1-fb44-4cd6-af96-f109303707ba",
  "title": "Clean Architecture: A Craftsman's Guide to Software Structure and Design",
  "description": "As with his other books, Martin's Clean Architecture ....",
  "author": "Robert C. Martin ",
  "coverImage": null,
  "price": 46.99
}
```
<br/>
<strong> <span style="color:#097bed;">PUT</span>&nbsp;  Update Book</strong> <br/>

` https://url/api/v1/Book/Update`
<br/>
We can edit and update the information of the books in this section<br/>
###### Body (Json)
```json
{
  "id": "b386a956-5f35-4879-b92b-158d42f8749e",
  "title": "C++ Primer Paperback",
  "description": "Fully updated and recast for the newly....",
  "author": "Stanley Lippman, Josée Lajoie, Barbara Moo",
  "coverImage": null,
  "price": 25
}
```
###### Sample Result Message
```json
Update row successful
```
<br/>
<strong> <span style="color:#097bed;">DEL</span>&nbsp; Delete Book</strong> <br/>

` https://url/api/v1/Book/Delete`
<br/>
Removing book is possible with entering ID<br/>
###### Body (Json)
```json
{
  "id": "b386a956-5f35-4879-b92b-158d42f8749e"
}
```
###### Sample Result Message
```json
Delete row successful
```
