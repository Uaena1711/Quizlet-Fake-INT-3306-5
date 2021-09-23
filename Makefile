DB_IMAGE=mcr.microsoft.com/mssql/server
DB_CONTAINER_NAME=aaaa
FRONT_END_NAME=bbbb
BACK_END_NAME=cccc
DB_EXIST := $(shell docker ps -a --filter name=${DB_CONTAINER_NAME} | grep ${DB_CONTAINER_NAME})
DB_STARTED := $(shell docker ps --filter name=${DB_CONTAINER_NAME} | grep ${DB_CONTAINER_NAME})
BACK_END_EXIST := $(shell docker ps -a --filter name=${BACK_END_NAME} | grep ${BACK_END_NAME})
BACK_END_STARTED := $(shell docker ps --filter name=${BACK_END_NAME} | grep ${BACK_END_NAME})
FRONT_END_EXIST := $(shell docker ps -a --filter name=${FRONT_END_NAME} | grep ${FRONT_END_NAME})
FRONT_END_STARTED := $(shell docker ps --filter name=${FRONT_END_NAME} | grep ${FRONT_END_NAME})

db-init:
ifdef DB_EXIST
			@echo "==> Checking sql server container"
ifdef DB_STARTED
			@echo "==> Sql server Already started"
else
			@echo "==> Starting Sql server container"
			@docker start $(DB_CONTAINER_NAME)
endif
else
			@echo "==> Creating new Sql server container"
			@echo "==> No image found trying to build one..."
			@docker pull mcr.microsoft.com/mssql/server && docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=leeji-eun1" --name $(DB_CONTAINER_NAME) -p 1433:1433 -d --network host $(DB_IMAGE)
endif

run-backend:
ifdef BACK_END_EXIST
			@echo "===> Checking back end container"
ifdef BACK_END_STARTED
			@echo "===> Back end already started"
else
			@echo "Start back end container"
			@docker start $(BACK_END_NAME)
endif
else
			@cd aspnet-core; $(MAKE) build-back-end && $(MAKE) run-back-end; cd -
endif
run-front-end:
ifdef FRONT_END_EXIST
			@echo "===> Checking front end container"
ifdef FRONT_END_STARTED
			@echo "===> Front end already started"
else
			@echo "Start front end container"
			@docker start $(FRONT_END_NAME)
endif
else
			@cd angular; $(MAKE) run-front-end; cd -
endif

start:
	make db-init && make run-backend && make run-front-end

stop:
	docker stop $(DB_CONTAINER_NAME) $(BACK_END_NAME) $(FRONT_END_NAME)

remove:
	docker container rm -f  $(DB_CONTAINER_NAME) $(BACK_END_NAME) $(FRONT_END_NAME)
