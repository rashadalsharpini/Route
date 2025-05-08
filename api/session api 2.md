## Asynchronous and Synchronous
### Synchronous
- Wait until **everything is done** before moving to the next step.
- Each operation **blocks** the program until it finishes.
- **Example:**  
    When you read a file, the program **won't continue** until the file is **completely** read.
---
### Asynchronous
- **Non-blocking** architecture — the program **keeps running** without waiting, as long as **nothing depends** on the result.
- Tasks can **happen in the background**, and the program will **pick up** the result when it’s ready.
- **Example:**  
    You start reading a file, but immediately continue running other code.  
    When the file is done reading, you handle the result.

---
### Synchronous 
is a blocking architecture As a single-thread model, it follows a strict set
of sequences, which means that operations are performed one at a time, in order. While
one operation is being performed, other operations' instructions are blocked. The
completion of the first task triggers the next, and so on

### Asynchronous 
is a non-blocking architecture, so the execution of one task isn't
dependent on another , Increases Performance because multiple operations can run at
the same time.

---


![[asynchronous and synchronous.png]]

![[Pasted image 20250427153320.png]]
