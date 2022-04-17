=================
Simple dotnet app
=================

This is a starter project for the third laboratory assignment on containerization.

How to run
==========

You will need `dotnet core <https://dotnet.microsoft.com/en-us/download>`_ platform  installed in
order to compile this project.

Build the project with the following command:

.. code-block:: console

   solo@falcon ~/project $ dotnet build

When you have the project built, you can run it by invoking the binary (exe or dll - for your choice):

.. code-block:: console

   solo@falcon ~/project $ dotnet bin\Debug\netcoreapp3.1\lab-03-dotnet.dll
   Listening on http://0.0.0.0:8080
   ...

When serving a project, press Ctrl+C to sent SIGTERM signal to the running
server and bring it down.
