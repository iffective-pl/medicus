FROM nginx
WORKDIR /etc/nginx
COPY .htpasswd .
RUN mkdir ssl
COPY keys/public.key ssl
COPY keys/private.key ssl
COPY dev.conf conf.d/default.conf