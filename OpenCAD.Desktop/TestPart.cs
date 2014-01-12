﻿using System;
using System.Collections.Generic;
using OpenCAD.Kernel;
using OpenCAD.Kernel.Maths;
using OpenCAD.Kernel.Modeling;
using OpenCAD.Kernel.Modeling.Octree;
using OpenCAD.Kernel.Primatives;
using OpenCAD.Kernel.Scripting;

namespace OpenCAD.Desktop
{
    public class TestPart:IPartScript
    {
        public IEnumerable<IPartScriptOption> Options()
        {
            throw new NotImplementedException();
        }

        public IModel Generate()
        {
            var s1 = new Sphere { Center = Vect3.Zero, Radius = 4 };
            var t = new OctreeNode(Vect3.Zero, 16, 5);
            var t1 = t.Intersect(node =>
            {
                if (node.AABB.Inside(s1)) return OctreeNode.NodeIntersectResult.Inside;
                if (s1.Intersects(node.AABB)) return OctreeNode.NodeIntersectResult.True;
                return OctreeNode.NodeIntersectResult.False;
            });
            return new OctreeModel(t1, "Test Octree");
        }
    }
}
