

build-back-end:
	docker build -t quiz:latest --network=host .

run-back-end:
	docker run -d -p 44340:44340 --network host quiz:latest 