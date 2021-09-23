FROM node:14

WORKDIR /app

COPY . .

RUN npm install -g @angular/cli@latest

RUN npm install --save @angular-devkit/build-angular

RUN npm run build

EXPOSE 4200

CMD [ "npm", "run", "start" ]