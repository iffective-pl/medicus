FROM quay.io/keycloak/keycloak:latest as builder

ENV KC_HEALTH_ENABLED=false
ENV KC_METRICS_ENABLED=false
ENV KC_FEATURES=token-exchange
ENV KC_DB=postgres
RUN /opt/keycloak/bin/kc.sh build --spi-x509cert-lookup-provider=nginx

FROM quay.io/keycloak/keycloak:latest
COPY --from=builder /opt/keycloak/ /opt/keycloak/
WORKDIR /opt/keycloak
# for demonstration purposes only, please make sure to use proper certificates in production instead
RUN keytool -genkeypair -storepass password -storetype PKCS12 -keyalg RSA -keysize 2048 -dname "CN=auth" -alias auth -ext "SAN:c=DNS:localhost,IP:127.0.0.1" -keystore conf/server.keystore
# change these values to point to a running postgres instance
ENV KC_DB_URL=jdbc:postgresql://sql:5432/keycloak
ENV KC_DB_USERNAME=postgres
ENV KC_DB_PASSWORD="BdfUm*C@s2*QcbEUr8xOuqN*ciMbOS17f!xxPv8fA4k7^b38Hw"
ENV KC_HOSTNAME_STRICT=false
ENTRYPOINT ["/opt/keycloak/bin/kc.sh"]