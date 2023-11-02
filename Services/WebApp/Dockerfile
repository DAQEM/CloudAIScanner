FROM node:20.6.0-alpine3.18
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install production dependencies.
RUN npm install

# Copy local code to the container image.
COPY . .

# Run the web service on container startup.
CMD npm run dev -- --host 
