FROM nginx:alpine

# Удаляем стандартную конфигурацию Nginx
RUN rm -f /etc/nginx/conf.d/default.conf

# Подменяем её кастомной конфигурацией
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Копируем сжатую сборку игры
COPY Builds/WebGL/ /usr/share/nginx/html/

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]