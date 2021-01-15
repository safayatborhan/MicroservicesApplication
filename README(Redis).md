# MicroservicesApplication REDIS

- get redis from docker hub (docker pull redis)

To see if this images is installed successfully installed on machine: 
- docker pull redis

You can get these commands from docker hub and search for a particular docker image. They provides these commands to pull images. 
Run following command to see if docker mongo image is installed.
- docker images

Run this image : 
- docker run -d -p 6379:6379 --name aspnetrun-redis redis (-p is port number parameter. -name is name of the container. and lastly redis is the image name)

After successfully running this command, you will able to see one docker redis container running and you can see this by this command : 
- docker ps

Let's execute the container. Write this command : 
- docker exec -it aspnetrun-redis /bin/bash

Here, we can execute some redis command. 
- redis-cli
- ping
- set key value (assigns "value" into key)
- get key ("value")

After developing the api and other repositories, we will have to modify docker compose and docker file in that microservice. Then we need to run this docker compose file. 
For this, let's move to that docker compose project directory and stop all running docker container first. To see currently running docker containers : 
- docker ps

To stop containers: 
- docker stop 12 (12 is first two characters of docker container ID)

Stop all containers like this way and after make sure is there is not any container running. We will run docker compose file now. 
- D:\personal\Works\MicroservicesApplication\MicroservicesApp>docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

After successfully running this script, we will be able to run these two microservices into two different port, as we included into that docker compose file. For reference: 
- http://localhost:8001/swagger/index.html
- http://localhost:8000/swagger/index.html