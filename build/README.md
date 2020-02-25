#https://hackernoon.com/docker-commands-the-ultimate-cheat-sheet-994ac78e2888

#Build Docker Image from a file.
#docker build -t <ImageName> -f <DockerFile> .

#Push Docker Image to Registry
#docker push <ImageName>

#Check Docker Images
#docker images

#Check docker containers
#docker ps
#docker ps -a

#Run Container from Image
#docker run -it -p <HostPort:ContainerPort> --name <ContainerName> <ImageName>
