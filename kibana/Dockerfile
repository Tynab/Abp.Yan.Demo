ARG ELASTIC_VERSION

# https://www.docker.elastic.co/
FROM docker.elastic.co/kibana/kibana:${ELASTIC_VERSION}

# Add your kibana plugins setup here
# Example: RUN kibana-plugin install <name|url>

RUN echo ${KIBANA_SYSTEM_PASSWORD} | bin/kibana-keystore add elasticsearch.password --stdin
