import pandas as pd
df = pd.read_csv("202011_202104_.csv")
from sklearn.model_selection import train_test_split
x = df[['순창IC-남원JC교통량']]
y = df[['남원JC-남원IC교통량']]
x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()

#print("기울기")
#print(mlr.coef_)
#print("상수")
#print(mlr.intercept_)
print("<T12-2와의 각 선형회귀값>\n")
print("T11-2 정확도")
print(mlr.score(x_train, y_train))
print("\n")



y = df[['남원JC-순창IC교통량']]
x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()
print("T12 정확도")
print(mlr.score(x_train, y_train))
print("\n")




y = df[['북남원IC-남원JC교통량']]
x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()
print("T1-2 정확도")
print(mlr.score(x_train, y_train))
print("\n")



y = df[['남원JC-북남원IC교통량']]
x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()
print("T1 정확도")
print(mlr.score(x_train, y_train))
print("\n")




y = df[['남원IC-남원JC교통량']]
x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()
print("T11 정확도")
print(mlr.score(x_train, y_train))
print("\n")



y = df[['남원JC-서남원IC교통량']]
x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()
print("T10 정확도")
print(mlr.score(x_train, y_train))
print("\n")




y = df[['서남원IC-남원JC교통량']]
x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()
print("T10-2 정확도")
print(mlr.score(x_train, y_train))
print("\n")





