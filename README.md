# House Price Prediction - ML.NET

## Overview

Welcome to the **House Price Prediction** ML.NET project! This solution leverages machine learning to predict house prices based on features such as area, age, number of rooms, district, and price per meter. It includes both a **manual ML pipeline implementation** and an **auto-generated model** from ML.NET Model Builder.

The goal of this project is to demonstrate how to load real estate data, build and evaluate regression models, and generate predictions using both manual and automated ML workflows.

## Projects in the Solution

- **HousePricePrediction**: Contains the dataset (`dataset.csv`) and shared resources.
- **HousePricePrediction_Manual**: A manually coded ML pipeline using `FastTreeTweedie` regression and evaluation metrics.
- **HousePricePrediction_Auto**: A model auto-generated using ML.NET Model Builder for quick and easy experimentation.

---

## Features

### Manual Model Training (`HousePricePrediction_Manual`)

- Load data from a CSV file.
- Preprocess data by replacing missing values and normalizing.
- Train a regression model using `FastTreeTweedie`.
- Evaluate model performance with metrics: R², MAE, MSE, RMS.
- Predict prices on unseen test data.

### Auto-generated Model (`HousePricePrediction_Auto`)

- Auto-generated ML pipeline using ML.NET Model Builder.
- Predict price using a single hardcoded input.
- Simpler and faster but less flexible than manual implementation.

---

## Dataset

The dataset (`dataset.csv`) contains information about properties:

| Index | Area | Age | Rooms | District | PricePerMeter | Price       |
|-------|------|-----|-------|----------|----------------|-------------|
| 0     | 134  | 1   | 3     | 2        | 64.51          | 13400000000 |
| 1     | 58   | 10  | 1     | 2        | 64.51          | 4600000000  |
| ...   | ...  | ... | ...   | ...      | ...            | ...         |

Each row represents a house and its corresponding sale price.

---

## Model Pipeline (Manual)

1. Load data from `dataset.csv`.
2. Replace missing values for numerical columns.
3. Concatenate features into a single vector.
4. Normalize feature values.
5. Train the model using FastTreeTweedie regression.
6. Evaluate and output performance metrics.
7. Predict and print price values for test set.

---

## Evaluation Metrics Output Example
### Metrics for FastTreeTweedie regression model
### -----------------------------------

LossFn: 2.3E+17

R2 Score: 0.85

Absolute loss: 1.5E+08

Squared loss: 2.3E+17

RMS loss: 4.8E+08

---

## How to Run

### Manual Approach

1. Open the solution in Visual Studio.
2. Set `HousePricePrediction_Manual` as the startup project.
3. Press `F5` or run the project.
4. The console app will:
   - Train the model.
   - Print evaluation metrics.
   - Predict house prices on test data and output them.

### Auto Approach

1. Set `HousePricePrediction_Auto` as the startup project.
2. Run the project to see prediction on a predefined sample input.

---

## Screenshots

### Console Output (Manual)

![Manual Prediction Console Output](https://github.com/ElliotOne/House-Price-Prediction/blob/master/screenshots/first.png)

### Model Builder UI (Auto)

![Model Builder UI](https://github.com/ElliotOne/House-Price-Prediction/blob/master/screenshots/second.png)

![Model Builder Console](https://github.com/ElliotOne/House-Price-Prediction/blob/master/screenshots/third.png)

---

## Technologies Used

- [.NET 6](https://dotnet.microsoft.com/)
- [ML.NET](https://learn.microsoft.com/en-us/dotnet/machine-learning/)
- [Visual Studio](https://visualstudio.microsoft.com/)

---

## License

This project is licensed under the MIT License. Feel free to use, share, and improve it!

---

## Contributions

Pull requests and suggestions are welcome! For major changes, please open an issue first to discuss what you would like to change.
