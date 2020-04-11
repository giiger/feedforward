//
//  main.cpp
//  NNTraining
//
//  Created by Michael Schuff on 4/10/20.
//  Copyright © 2020 Michael Schuff. All rights reserved.
//

#include <iostream>
#include <vector>
#include <cmath>
#include <ctime>
#include <cstdlib>
#include <SFML/Graphics.hpp>
#include "SplinePoint2D.hpp"
#include "Vector2D.hpp"
#include "MathFunctions.hpp"
#include "Spline2D.hpp"
#include "Hamiltonian.hpp"

using namespace std;
using namespace sf;
using namespace MathFunctions;

double degrees(double);
double radians(double);
RectangleShape VectorLine(Vector2D, Vector2D);
RectangleShape Line(double, double, double, double, Color);
void DrawSpline(RenderWindow&, Spline2D, double);

int main() {
    srand(time(NULL));
    enum State {leftDown, rightDown, up};
    State mouseState = up;
    
    double mx, my, controlPointRadius = 5, width = 800, height = 800;
    int splinePointIndex = -1, controlPointIndex = -1;
    bool clear = true;
    vector<SplinePoint2D> controlPoints;
    
    int rows = 3 + rand() % 2;
    int columns = rows + (2 * (rand() % 2)) - 1;
    double pxPerRow = (double) height / rows;
    double pxPerColumn = (double) height / columns;
    vector<Vector2D> points;
    Vector2D start((int) 0, (int) 0);
    vector<vector<Vector2D>> path = Hamiltonian::ManhattanCycleDiagonal(rows, columns);
    Vector2D p((int) 0, (int) 0);
    do {
        Vector2D temp((float) (pxPerColumn*(p.x+.25+.5*((double)rand())/RAND_MAX)), (float) (pxPerRow*(p.y+.25+.5*((double)rand())/RAND_MAX)));
        points.push_back(temp);
        p -= path[p.y][p.x];
    } while (p != start);
    vector<double> multipliers = {1, 5};
    
    vector<Vector2D> dPoints;
    for (int i = 0; i < points.size(); i++) {
        int l = (points.size() + i - 1) % points.size(), r = (i + 1) % points.size();
        dPoints.push_back(Vector2D((points[r]-points[l]).scaled(50)));
//        dPoints.push_back(Vector2D((float) tx, (float) ty));
    }
    
    for (int i = 0; i < points.size(); i++) {
        controlPoints.push_back(SplinePoint2D(vector<Vector2D> {points[i], dPoints[i]}, multipliers));
    }
//
//    vector<SplinePoint2D> controlPoints = {
//        SplinePoint2D(vector<vector<double>> {{200, 200}, {50, -50}}, multipliers),
//        SplinePoint2D(vector<vector<double>> {{400, 100}, {50, 0}}, multipliers),
//        SplinePoint2D(vector<vector<double>> {{600, 200}, {50, 50}}, multipliers),
//        SplinePoint2D(vector<vector<double>> {{700, 400}, {0, 50}}, multipliers),
//        SplinePoint2D(vector<vector<double>> {{600, 600}, {-50, 50}}, multipliers),
//        SplinePoint2D(vector<vector<double>> {{400, 700}, {-50, 0}}, multipliers),
//        SplinePoint2D(vector<vector<double>> {{200, 600}, {-50, -50}}, multipliers),
//        SplinePoint2D(vector<vector<double>> {{100, 400}, {0, -50}}, multipliers)
//    };
    
    Spline2D spline(controlPoints, true);

    RenderWindow window(VideoMode(width, height), "Spliney Boiz");
    while (window.isOpen()) {
        Event event;
        while (window.pollEvent(event)) {
            if (event.type == Event::Closed) {
                window.close();
            }
            if (event.type == Event::KeyPressed && event.key.code == Keyboard::Escape) {
               window.close();
            }

        }
        
        if (Mouse::isButtonPressed(Mouse::Left)) {
            mouseState = leftDown;
        } else if (Mouse::isButtonPressed(Mouse::Right)) {
            mouseState = rightDown;
        } else {
            mouseState = up;
            clear = true;
        }
        
        if (mouseState != up) {
            mx = Mouse::getPosition(window).x;
            my = Mouse::getPosition(window).y;
            if (clear) {
                double minDistance = controlPointRadius;
                for (int i = 0; i < controlPoints.size(); i++) {
                    double x = 0, y = 0;
                    for (int j = 0; j < controlPoints[i].controlPoints.size(); j++) {
                        x += controlPoints[i].GetX(j);
                        y += controlPoints[i].GetY(j);
                        double distFromPoint = sqrt(pow(mx-x, 2) + pow(my-y, 2));
                        if (distFromPoint < minDistance) {
                            minDistance = distFromPoint;
                            splinePointIndex = i;
                            controlPointIndex = j;
                        }
                    }
                }
                clear = false;
            }
            if (splinePointIndex != -1) {
                if (mouseState == leftDown) {
                    controlPoints[splinePointIndex].SetPositionKeepLocal(mx, my, controlPointIndex);
                } else if (mouseState == rightDown) {
                    controlPoints[splinePointIndex].SetPosition(mx, my, controlPointIndex);
                }
                spline.SetControlPoints(controlPoints);
            }
        } else {
            splinePointIndex = -1;
            controlPointIndex = -1;
        }
        window.clear();
        DrawSpline(window, spline, controlPointRadius);
//        for (int i = 0; i < points.size(); i++) {
//            CircleShape p(5);
//            p.setOrigin(5, 5);
//            p.setFillColor(Color(255,255,255));
//            p.setPosition(points[i].x, points[i].y);
//            window.draw(p);
//        }
//        for (int i = 0; i < points.size() - 1; i++) {
//            window.draw(Line(points[i].x, points[i].y, points[i+1].x, points[i+1].y, Color(255,255,255)));
//        }
        window.display();
    }
    
}

void DrawSpline(RenderWindow &window, Spline2D spline, double controlPointRadius = 5.0) {
    vector<Color> controlPointColors = {Color(255, 0, 0), Color(255, 255, 0), Color(0, 255, 0), Color(0, 255, 255), Color(0, 0, 255), Color(255, 0, 255)};
    Vector2D last = spline.Get(0), current(0, 0);
    double tInc = 0.001;
    for (double t = tInc; t < 1; t+=tInc) {
        current = spline.Get(t);
        window.draw(VectorLine(last, current));
        last = current;
    }
    
    for (int i = 0; i < spline.controlPoints.size(); i++) {
        double x = spline.controlPoints[i].GetX(0), y = spline.controlPoints[i].GetY(0);
        for (int j = 0; j < spline.controlPoints[i].controlPoints.size() - 1; j++) {
            CircleShape p(controlPointRadius);
            p.setOrigin(controlPointRadius, controlPointRadius);
            p.setFillColor(controlPointColors[j % controlPointColors.size()]);
            p.setPosition(x, y);
            window.draw(Line(x, y, x+spline.controlPoints[i].GetX(j+1), y+spline.controlPoints[i].GetY(j+1), Color(100, 100, 100)));
            window.draw(p);
            x += spline.controlPoints[i].GetX(j+1);
            y += spline.controlPoints[i].GetY(j+1);
            
        }
        CircleShape p(controlPointRadius);
        p.setOrigin(controlPointRadius, controlPointRadius);
        p.setFillColor(controlPointColors[spline.controlPoints[i].controlPoints.size() % controlPointColors.size()]);
        p.setPosition(x, y);
        window.draw(p);
    }
}

RectangleShape VectorLine(Vector2D v1, Vector2D v2) {
    return Line(v1.x, v1.y, v2.x, v2.y, Color(255, 255, 255));
}

RectangleShape Line(double x1, double y1, double x2, double y2, Color color) {
    double x = x2 - x1;
    double y = y2 - y1;
    RectangleShape line(Vector2f(sqrt(x*x+y*y),1));
    line.setOrigin(0.5, 0.5);
    line.rotate(degrees(atan2(y,x)));
    line.setPosition(x1, y1);
    line.setFillColor(color);
    return line;
}

double radians(double deg) {
    return deg * 3.1415626535 / 180;
}

double degrees(double rad) {
    return rad * 180 / 3.1415626535;
}
