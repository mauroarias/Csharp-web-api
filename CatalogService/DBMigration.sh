#!/bin/bash

VALID_ARGS=$(getopt -o icurh: --long install,create,update,remove,help: "$@")
if [[ $? -ne 0 ]]; then
    exit 1;
fi

eval set -- "$VALID_ARGS"
while [ : ]; do
  case "$1" in
    -i | --install)
        install
        exit 0
        ;;
    -c | --create)
        migration_name=$2
        create_migration
        shift 2
        ;;
    -u | --update)
        update_migration
        shift
        ;;
    -r | --remove)
        remove_migration
        shift
        ;;
    -h | --help)
        remove_migration
        shift
        ;;
  esac
done

install() {
   dotnet tool install -g dotnet-ef
} 

create_migration() {
   dotnet ef migrations add $migration_name
} 

remove_migration() {
   dotnet ef migrations remove
}

update_migration() {
   dotnet ef migrations update
}