FROM postgres:latest

RUN apt-get update && apt-get install -y locales locales-all \
    && echo "pt_BR.UTF-8 UTF-8" > /etc/locale.gen \
    && locale-gen pt_BR.UTF-8 \
    && update-locale LANG=pt_BR.UTF-8 \
    && dpkg-reconfigure --frontend=noninteractive locales \
    && update-locale LANG=pt_BR.UTF-8

ENV LANG pt_BR.UTF-8
ENV LC_ALL pt_BR.UTF-8

COPY ./script/*.sql /docker-entrypoint-initdb.d/