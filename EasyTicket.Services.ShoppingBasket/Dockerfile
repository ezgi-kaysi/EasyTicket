#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["EasyTicket.Services.ShoppingBasket/EasyTicket.Services.ShoppingBasket.csproj", "EasyTicket.Services.ShoppingBasket/"]
COPY ["EasyTicket.Messages/EasyTicket.Messages.csproj", "EasyTicket.Messages/"]
COPY ["EasyTicket.MessagingBus/EasyTicket.MessagingBus.csproj", "EasyTicket.MessagingBus/"]
RUN dotnet restore "EasyTicket.Services.ShoppingBasket/EasyTicket.Services.ShoppingBasket.csproj"
COPY . .
WORKDIR "/src/EasyTicket.Services.ShoppingBasket"
RUN dotnet build "EasyTicket.Services.ShoppingBasket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyTicket.Services.ShoppingBasket.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyTicket.Services.ShoppingBasket.dll"]