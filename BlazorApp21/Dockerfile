FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY BlazorApp21.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish BlazorApp21.csproj -c Release -o /app/publish

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf

# Render uses $PORT dynamically
CMD sh -c "envsubst '\$PORT' < /etc/nginx/nginx.conf > /tmp/nginx.conf && nginx -c /tmp/nginx.conf -g 'daemon off;'"