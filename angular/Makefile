FRONT_END_NAME=bbbb
run-front-end:
	docker build -t quiz-front:latest --network=host .
	docker run -d --name $(FRONT_END_NAME) -p 80:4200 --network host quiz-front:latest