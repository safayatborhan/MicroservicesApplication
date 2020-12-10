# MicroservicesApplication

Docker notes : 
At the very beginning we will need mongo db and we are going to use it from docker. 
At first put this command to see if there is any docker container into local machine : 
- docker ps

If docker any container was installed previously, then it will show here. As we are installing it for the very first time, we should not see any docker container. 
To install docker mongodb container we will need to get and run docker mongo db image first. Run the following command: 
- docker pull mongo

You can get these commands from docker hub and search for a particular docker image. They provides these commands to pull images. 
Run following command to see if docker mongo image is installed.
- docker images

You will see docker image is up and running into local machine. Let's create a mongo container then. Write this command : 
- docker run -d -p 27017:27017 --name aspnetrun-mongo mongo (-p is port number parameter. -name is name of the container. and lastly mongo is the image name)

After successfully running this command, you will able to see one docker mongo container running and you can see this by this command : 
- docker ps

Let's execute the container. Write this command : 
- docker exec -it aspnetrun-mongo /bin/bash

Docker container can exit sometimes later. Don't know right now why is that. We will have to manually start that container. For that, execute the following command : 
- docker ps -a

This will return all containers whether it is running or exited. Copy that ID of the container you want to start and run following command : 
- docker start ID

Then if you run "docker ps", you will get that container running. "docker ps" only returns the running containers.

This will run this container and move into the container directory. We can write basic commands into that directory like : 
- ls

Here we will give a command and hit enter.
- mongo

This will allow us to write mongo commands.
- show dbs (show the exisiting databases of mongo)

- use CatalogDb(creates a new database named CatalogDb and switch into that database)

- db.createCollection('Products') (this will create a collection into that CatalogDb)

- show collections (this will return all collections)

Add a new product into the database : 
- 
db.Products.insertMany(
 [
	{
		"Name": "Rappo Keyboard",
		"Category": "Computers",
		"Summary": "Summary",
		"Description": "Description",
		"ImageFile": "ImageFile",
		"Price": 54.55
	},
	{
		"Name": "Rappo Keyboard 2",
		"Category": "Computers 2",
		"Summary": "Summary 2",
		"Description": "Description 2",
		"ImageFile": "ImageFile 2",
		"Price": 54.55
	}
 ])
 
 
 - db.Products.find({}).pretty() (to get all products in a formatted way)
 
 