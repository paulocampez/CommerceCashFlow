#!/bin/bash

set -e

# Apply database migrations
dotnet ef database update --project CommerceCashFlow.Infrastructure

# Start the API
exec dotnet CommerceCashFlow.Api.dll