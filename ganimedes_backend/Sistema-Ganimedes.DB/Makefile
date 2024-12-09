up:
	sudo docker-compose up -d

down:
	sudo docker-compose down

destroy-container:
	sudo docker-compose down --volumes --remove-orphans
	sudo docker volume prune -f
	sudo docker network prune -f