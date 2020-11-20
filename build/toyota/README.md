#########################-->NGINX PLUS Docker Image<--###########################   
#Trial expires on 2020-12-20   
`https://www.nginx.com/blog/deploying-nginx-nginx-plus-docker/`  

`docker build -t nginx-test -f Dockerfile.nginx_plus .`  
`docker run -it -d -P --env-file env_vars_nginx_plus --name nginx_plus nginx_plus`  
`docker exec -it nginx_plus bash`  
#################################################################################   

#########################-->NGINX TEST Docker Image<--###########################   
`docker build -t nginx-test -f Dockerfile.nginx_test .`  
`docker run -it -d -P --env-file env_vars_nginx_test --name nginx_plus nginx_test`  
`docker exec -it nginx_test bash`  
#################################################################################  
