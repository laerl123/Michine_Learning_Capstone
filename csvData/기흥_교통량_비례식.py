import pandas as pd
import numpy as np
from sklearn.linear_model import LinearRegression
import matplotlib.pyplot as plt
import csv

my_list=[['상수','T2','T4']]

t1 = pd.read_csv("t1.csv")
t3 = pd.read_csv("t3.csv")
t5 = pd.read_csv("t5.csv")

t2 = pd.DataFrame()
t2 = t3[['교통량']] - t1[['교통량']]

t4 = pd.DataFrame()
t4 = t5[['교통량']] - t3[['교통량']]

df = pd.DataFrame()
df = pd.concat([t1, t2], axis=1)
df = pd.concat([df, t3], axis=1)
df = pd.concat([df, t4], axis=1)

df1 = pd.DataFrame()
df1 = pd.concat([t2,t4], axis=1)

X = df1[['교통량']]
y = t5[['교통량']]

model = LinearRegression()
model.fit(X, y)

y_predict = model.predict(X)

print(model.coef_)

print(model.intercept_[0],model.coef_[0][0],model.coef_[0][1])

my_list[0][0]= model.intercept_[0]
my_list[0][1]= model.coef_[0][0]
my_list[0][2]= model.coef_[0][1]

dataframe = pd.DataFrame(my_list)
dataframe.to_csv("기흥_교통량_비례식계수.csv",header=False, index=False)
