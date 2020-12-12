#!/usr/bin/env bash

###-->This Script Interpolates Container Environment Variables, defined in nginx.conf<--###

set -eu

configs=(/etc/nginx/nginx.conf /usr/share/nginx/html/index.html)

for config in ${configs[@]}
do
  conf=${config##*/}
  cp -rp $config /tmp/$conf
  envsubst "$(env | awk -F = '{printf " $%s", $1}')" < /tmp/$conf > /tmp/$conf.rendered
  mv /tmp/$conf.rendered $config
  rm /tmp/$conf
done

exec "$@"

########################################-->END<--##########################################
