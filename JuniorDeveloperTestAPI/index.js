const express = require("express");
const dotenv = require("dotenv");
const cors = require("cors");
const Repositories = require("./src/routes/repositories");
const app = express();

dotenv.config();
app.use(cors());
app.use(express.json());

app.listen(process.env.PORT || 5000, () => {});

app.use("/api/repositories", Repositories);
