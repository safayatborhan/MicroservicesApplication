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