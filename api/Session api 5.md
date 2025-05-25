difference between POST and PUT
### **POST**

- **Purpose:** Create a **new** resource.
    
- **Usage:** When you **don't know the URL** of the resource in advance — the server decides it.
    
- **Idempotency:** **Not idempotent** — multiple identical POSTs create multiple resources.

---

### **PUT**

- **Purpose:** Create or **replace** a resource at a **known** URL.
    
- **Usage:** When the **client knows the exact URL** and wants to fully update or create it.
    
- **Idempotency:** **Idempotent** — multiple identical PUTs result in the same resource.

|Feature|POST|PUT|
|---|---|---|
|Creates|New resource|New or replaces existing|
|Resource URL|Server decides|Client decides|
|Idempotent|❌ No|✅ Yes|
|Common Use|Submitting forms, new entries|Updating full records|