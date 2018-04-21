const express = require('express');
const router = express.Router();
const mongoose = require('mongoose');

//Import database model
const Games = require('../models/games');

router.get('/', (req, res, next) => {
  Games.find().exec().then(docs => {
    console.log(docs);
    res.status(200).json(docs);
  }).catch(err => {
    //Log error to console and send HTTP error
    console.log(err);
    res.status(500).json({
      error: err
    });
  });
});

router.post('/', (req, res, next) => {

  //Create database model object to allow data to be posted to database
  const game = new Games({
    _id: new mongoose.Types.ObjectId(),
    title: req.body.title,
    console: req.body.console,
    genre: req.body.genre
  });

  //Save to database and log to the console
  //Also log errors to the console
  game.save().then(result => {
    console.log(result);
    //Send successful status message here so it passes through the data check
    res.status(201).json({
      message: 'Game Entry was posted',
      createdGame: result
    });
  }).catch(err => {
    console.log(err);
    res.status(500).json({
      error: err
    });
  });
});

router.get('/:gameId', (req, res, next) => {
  const id = req.params.gameId;
  Games.findById(id).exec().then(doc => {
    console.log("From database", doc);
    if (doc) {
      res.status(200).json(doc);
    } else {
      res.status(404).json({
        message: 'No valid entry found for provided ID'
      });
    }
  }).catch(err => {
    console.log(err);
    res.status(500).json({
      error: err
    });
  });
});

router.patch("/:gameId", (req, res, next) => {
  const id = req.params.gameId;
  //Assign array varaible to assist with updates
  const updateOps = {};
  //Loop through entries to see what needs updating
  for (const ops of req.body) {
    //Check for specific update area and assign a value if it needs updated
    updateOps[ops.propName] = ops.value;
  }
  //Match id's to ensure successful update and set the updated values
  Games.update({ _id: id }, { $set: updateOps }).exec().then(result => {
    console.log(result);
    res.status(200).json(result);
  }).catch(err => {
    console.log(err);
    res.status(500).json({
      error: err
    });
  });
});

router.delete('/:gameId', (req, res, next) => {
  const id = req.params.gameId;
  Games.remove({
    //Match id's to ensure successful removal
    _id: id
  }).exec().then(result => {
    res.status(200).json(result);
  }).catch(err => {
    console.log(err);
    res.status(500).json({
      error: err
    });
  });
});

module.exports = router;
