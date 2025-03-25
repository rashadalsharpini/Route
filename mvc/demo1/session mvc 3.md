### architectural patterns
- all in one
- n tiers / layers
	- 3 tiers
#### 3 tiers architectural pattern
- user interface
- business logic
- data access
#### clean architecture / onion view / onion architecture
every thing is depend on one layer
![[onion view or clean architecture.png]]
![[onion view or clean achitecture 2.png]]

---
- repositories design pattern
	- CRUD operations
		- create
		- read
		- update
		- delete
- unit of work
	- combine all the repos in one place
---
#### department module
 1. module data:
Department entity should have the following properties Id [PK] , Name, Code , Description
>[!note] each entity type will have:
>- CreatedBy Property For UserId who Insert the Record
>- CreatedOn Property For Date Of Insertion
>- LastModifiedBy Property For UserId Who last modified it
>- LastModifiedOn Property For Date When it was last modified [Automatically Calculated ]
>- IsDeleted Flag To implement soft delete

---
#### dependency injection
Dependency Injection is a design pattern that helps achieve loose
coupling between components. Instead of creating dependencies manually ,
DI injects them automatically

----
#### Repository Pattern
The Repository Pattern is a design pattern that abstracts data access
logic from the business logic

---
![[basic architecture for data access layer.png]]
- `configurations` you configure the models / tables make the relations and propriety of the tables
- `contexts` you create the data base and and the tables within data base using db-set
- `models` which is the tables
- `repos` has the CRUD operations
![[tree to remember the department.png]]

---
#### mapping
- manual mapping
```cs
// BusinessLogic/Services/DepartmentServices.cs
public DepartmentDetailsDTO? Getdepartmentbyid(int departmentId)  
{  
    var department = _departmentRepo.GetDepartmentById(departmentId);  
    if (department is null) return null;  
    else  
    {  
        return new DepartmentDetailsDTO()  
        {  
            DepartmentName = department.DepartmentName,  
            Code = department.Code,  
            Description = department.Description,  
            createdOn = DateOnly.FromDateTime(department.createdOn)  
        };    
    }
}
```
- auto mapper (package)
- constructor mapping
```cs
// BusinessLogic/DataTransferObjects/DepartmentDetailsDTO.cs
public DepartmentDetailsDTO(Department department)  
{  
    DepartmentName = department.DepartmentName;  
    Code = department.Code;  
    Description = department.Description;  
    createdOn = DateOnly.FromDateTime(department.createdOn);  
}
// BusinessLogic/Services/DepartmentServices.cs
public DepartmentDetailsDTO? Getdepartmentbyid(int departmentId)  
{  
    var department = _departmentRepo.GetDepartmentById(departmentId);  
    return department is null ? null : new DepartmentDetailsDTO();  
}
```
- extension mapping
```cs
// BusinessLogic/Factories/DepartmentFactory.cs
public static class DepartmentFactory  
{  
    public static DepartmentDTO toDTO(this Department d)  
    {        return new DepartmentDTO()  
        {  
            DepartmentId = d.id,  
            code = d.Code,  
            Description = d.Description,  
            Name = d.DepartmentName,  
            dateCreated = DateOnly.FromDateTime(d.createdOn)  
        };    
    }  
    public static DepartmentDetailsDTO toDetailsDTO(this Department d)  
    {        return new DepartmentDetailsDTO()  
        {  
            DepartmentName = d.DepartmentName,  
            Code = d.Code,  
            Description = d.Description,  
            createdOn = DateOnly.FromDateTime(d.createdOn),  
        };  
    }
}
// BusinessLogic/Services/DepartmentServices.cs
public DepartmentDetailsDTO? Getdepartmentbyid(int departmentId)  
{  
    var department = _departmentRepo.GetDepartmentById(departmentId);  
    return department is null ? null : department.toDetailsDTO();  
}
```