FROM node:18-alpine AS build
WORKDIR /app

COPY package*.json ./

RUN npm install --legacy-peer-deps

COPY . .

RUN sed -i "s|http://localhost:5001/api/episodes|/api/episodes|g" src/environments/environment.ts

RUN npm run build

FROM nginx:alpine AS runtime
WORKDIR /usr/share/nginx/html

RUN rm -rf ./*

COPY --from=build /app/dist/browser ./

COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]