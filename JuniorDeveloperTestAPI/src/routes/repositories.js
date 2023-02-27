const router = require("express").Router();
const gitRequest = require("../controllers/gitRequestController");
const Constants = require("../constants/constants");

router.get("/", async (_req, res) => {
    try {
        const sortReq = await gitRequest();
        return res.status(Constants.STATUS.OK).json(sortReq);
    } catch (err) {
        return res.status(Constants.STATUS.ERROR).json(err);
    }
});

module.exports = router;
