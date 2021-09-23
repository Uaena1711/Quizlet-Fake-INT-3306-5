BACK_END_NAME=cccc
build-back-end:
	docker build -t quiz-back:latest --network=host .

run-back-end:
	docker run -d --name $(BACK_END_NAME) -p 44340:44340 --network host quiz-back:latest 